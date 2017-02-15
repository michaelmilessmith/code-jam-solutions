'use strict';

const fs = require('fs');

exports.solveProblem = (cookiesPerSecond, costOfFarm, cookiesPerFarmPerSecond, cookieTarget) => {
  let baseTime = Infinity
    , newTime = cookieTarget / cookiesPerSecond
    , timeToBuyFarms = 0;
  for (let i = 1; baseTime > newTime; i++){
    baseTime = newTime;
    timeToBuyFarms += costOfFarm / (cookiesPerSecond + ((i - 1) * cookiesPerFarmPerSecond));
    newTime = timeToBuyFarms + (cookieTarget / (cookiesPerSecond + (i * cookiesPerFarmPerSecond)));
  }
  return baseTime;
}

exports.solve = (data) => {
  const cases = data[0]
      , length = data.length
      , resultLines = [];
  for (let i = 1; i < length; i++){
    const [c, f, x] = data[i].split(" ");
    const result = this.solveProblem(2.0, c, f, x);
    resultLines.push(`Case #${i}: ${Math.round( result * 10000000 ) / 10000000}`)
  }
  return resultLines
};

const readSolveWrite = (fileNameIn, fileNameOut) => {
  fs.readFile(fileNameIn, 'utf-8', (error, contents) => {
    const data = contents.replace(/\r/g, '').split('\n').filter(String);
    fs.writeFile(fileNameOut, this.solve(data).join("\n"), (err) => {
        if(err) {
            return console.log(err);
        }
        console.log("The file was saved!");
    });
  })
};

readSolveWrite("B-small-practice.in", "B-small.out");
readSolveWrite("B-Large-practice.in", "B-large.out");
