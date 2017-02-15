'use strict';

var fs = require('fs');

const read = (fileName) => {
  return fs.readFileSync(fileName, 'utf-8').replace(/\r/g, '').split('\n').filter(String);
};

var dataSmall = read("B-small-practice.in");
var dataLarge = read("B-Large-practice.in");

exports.calculateTimeTaken = (cookiesPerSecond, costOfFarm, cookiesPerFarmPerSecond, cookieTarget) => {
  let baseTime = Infinity,
      newTime = cookieTarget / cookiesPerSecond
    , timeToBuyFarms = 0;
  for (let i = 1; baseTime > newTime; i++){
    baseTime = newTime;
    timeToBuyFarms += costOfFarm / (cookiesPerSecond + ((i - 1) * cookiesPerFarmPerSecond));
    newTime = timeToBuyFarms + (cookieTarget / (cookiesPerSecond + (i * cookiesPerFarmPerSecond)));
    // console.log({i, baseTime, newTime, timeToBuyFarms});
  }
  return baseTime;
}


exports.solveProblem = (cookiesPerSecond, costOfFarm, cookiesPerFarmPerSecond, cookieTarget) => {
    return this.calculateTimeTaken(cookiesPerSecond, costOfFarm, cookiesPerFarmPerSecond, cookieTarget);
};

exports.solve = (data) => {
  const cases = data[0],
        length = data.length,
        resultLines = [];
  for (let i = 1; i < length; i++){
    // console.log(`Case #${i}`);
    const [c, f, x] = data[i].split(" ");
    const result = this.solveProblem(2.0, c, f, x);
    resultLines.push(`Case #${i}: ${Math.round( result * 10000000 ) / 10000000}`)
  }
  return resultLines
};

fs.writeFile("B-small.out", this.solve(dataSmall).join("\n"), (err) => {
    if(err) {
        return console.log(err);
    }
    console.log("The file was saved!");
});

fs.writeFile("B-large.out", this.solve(dataLarge).join("\n"), (err) => {
    if(err) {
        return console.log(err);
    }
    console.log("The file was saved!");
});
