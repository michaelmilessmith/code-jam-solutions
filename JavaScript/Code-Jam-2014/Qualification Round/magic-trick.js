'use strict';

var fs = require('fs');
var data = fs.readFileSync("A-small-practice.in", 'utf-8').replace(/\r/g, '').split('\n').filter(String);

exports.solveProblem = (lines) => {
  const { arrayOne, arrayTwo } = this.readProblem(lines);
  return this.getResult(this.getMatchingNumbers(arrayOne, arrayTwo));
};

exports.getMatchingNumbers = (arrayOne, arrayTwo) => {
  const matches = [];
  for (let i = 0; i < arrayOne.length; i++){
    if(arrayTwo.includes(arrayOne[i])){
        matches.push(arrayOne[i]);
    }
  }
  return matches;
};

exports.getChosenRow = (chosen, rows) => {
  return rows[chosen - 1].split(" ").map( x => parseInt(x));
};

exports.readProblem = (lines) => {
  const [chosenOne, ...rowsOne] = lines.slice(0,5),
        [chosenTwo, ...rowsTwo] = lines.slice(5);

  const arrayOne = this.getChosenRow(parseInt(chosenOne), rowsOne),
        arrayTwo = this.getChosenRow(parseInt(chosenTwo), rowsTwo);
  return { arrayOne, arrayTwo };
};

exports.getResult = (matchingArray) => {
  switch(matchingArray.length){
    case 0 : return "Volunteer cheated!";
    case 1 : return matchingArray[0];
  }
  return "Bad magician!";
};

exports.solve = (data) => {
  const cases = data[0],
        length = data.length;
  for (let i = 1; i < length; i = i + 10){
    const result = this.solveProblem(data.slice(i, i + 10));
    console.log(`Case #${ (i + 9)/10 }: ${result}`);
  }
};

this.solve(data);
