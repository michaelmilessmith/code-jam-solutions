'use strict'

const fs = require('fs');

exports.naomiWarResult = (naomiBlocks, kenBlocks) => {
  const naomiBlocksSorted = naomiBlocks.slice(0).sort().reverse()
      , kenBlocksSorted = kenBlocks.slice(0).sort();
  let naomiPoints = 0;
  for(let n = 0; n < naomiBlocks.length; n++){
    const index = kenBlocksSorted.findIndex(b => b > naomiBlocksSorted[n]);
    if(index > -1){
      kenBlocksSorted[index] = 0;
    }
    else{
      naomiPoints += 1;
    }
  }
  return naomiPoints;
}

exports.naomiDeceitfulWarResult = (naomiBlocks, kenBlocks) => {
  return kenBlocks.length - this.naomiWarResult(kenBlocks, naomiBlocks);
}

exports.solveProblem = (naomiBlocks, kenBlocks) => {
  const warResult = this.naomiWarResult(naomiBlocks, kenBlocks)
      , deceitfulWarResult = this.naomiDeceitfulWarResult(naomiBlocks, kenBlocks);
  return { deceitfulWarResult, warResult };
}

exports.solve = (data) => {
  const cases = data[0]
  let resultLines = [];
  for (let i = 1; i <= cases; i++){
    const index = (i * 3) - 2;
    const naomiBlocks = data[index + 1].split(" ").map(Number)
        , kenBlocks = data[index + 2].split(" ").map(Number);
    const { deceitfulWarResult, warResult } = this.solveProblem(naomiBlocks, kenBlocks);
    resultLines.push(`Case #${i}: ${deceitfulWarResult} ${warResult}`);
  }
  return resultLines
};

const readSolveWrite = (fileNameIn, fileNameOut) => {
  fs.readFile(fileNameIn, 'utf-8', (error, contents) => {
    const data = contents.replace(/\r/g, '').split('\n').filter(String);
    fs.writeFile(fileNameOut, this.solve(data).join("\n").replace(/,/g, ''), (err) => {
        if(err) {
            return console.log(err);
        }
        console.log("The file was saved!");
    });
  })
};

readSolveWrite("D-small-practice.in", "D-small.out");
readSolveWrite("D-Large-practice.in", "D-large.out");
