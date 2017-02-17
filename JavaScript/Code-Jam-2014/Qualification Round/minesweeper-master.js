'use strict';

const fs = require('fs');
const _ = require('underscore');


exports.IsImpossible = (r, c, m) =>{
  const emptyspaces = (r * c) - m - 1;
  if(m === 0 || emptyspaces === 0){
    return false;
  }
  if((r === 1 || c === 1)){
    return false;
  }
  if((r === 2 || c === 2) && emptyspaces % 2 === 0){
    return true;
  }
  if (emptyspaces % 2 !== 0 && emptyspaces >= 3){
    return false;
  }
  if (emptyspaces % 2 === 0 && emptyspaces >= 8){
    return false;
  }
  return true;
}

exports.solveProblem = (r, c, m) => {
  if(this.IsImpossible(r, c, m)){
    return "Impossible";
  }
  const emptyspaces = (r * c) - m;
  const grid = _.range(r).map(() => {
        return _.range(c).map(() => {
            return '*';
        });
      });

  //If there is only one empty space we leave mines everywhere else
  if(emptyspaces === 1){
    grid[0][0] = "c";
    return grid;
  }

  //If there is only one row we can fill that easily
  if(r === 1){
    grid[0][0] = "c";
    for(let i = 1; i < emptyspaces; i++){
      grid[0][i] = ".";
    }
    return grid;
  }
  if(c === 1){
    grid[0][0] = "c";
    for(let i = 1; i < emptyspaces; i++){
      grid[i][0] = ".";
    }
    return grid;
  }

  //If we can fill the top two rows then fill then fill rows until availible space runs out
  if(emptyspaces === 2 * c || emptyspaces >= (2 * c) + 2){
    let total = 0;
    for (let y = 0; y < r && emptyspaces - total > 0; y++){
      if(c <= emptyspaces - total){
        grid[y].fill(".");
        total += c;
      }else{
        for(let x = 0; x < c && emptyspaces - total > 0; x++){
          grid[y][x] = ".";
          total += 1;
        }
      }
    }
    //Adjust orphan spaces
    for(let y = 0; y < r; y++){
      if(grid[y].filter(c => c === ".").length === 1){
        grid[y][1] = ".";
        grid[y - 1].pop();
        grid[y - 1].push("*");
      }
    }
  }else{ //else fill first two columns, then fill other columns until availible space runs out
    let total = 0;
    for(let y = 0; y < r && emptyspaces - total > 1; y++){
      grid[y][0] = ".";
      grid[y][1] = ".";
      total += 2;
    }
    for(let x = 2; x < c && emptyspaces - total > 0; x++){
      for(let y = 0; y < r && emptyspaces - total > 0; y++){
        grid[y][x] = ".";
        total += 1;
      }
    }
    //Adjust orphan spaces
    const length = grid[0].filter(c => c === ".").length;
    if(length % 2 !== 0 && grid[1][length - 1] !== "."){
      if(grid[2]){
        grid[1][length - 1] = ".";
        grid[2][length - 1] = ".";
        for (let i = grid.length - 1; i > 0; i--){
          if(grid[i].includes(".")){
            grid[i][0] = "*";
            grid[i][1] = "*";
            break;
          }
        }
      }
    }
  }

  //Set click space
  grid[0][0] = "c";

  return grid;
}

exports.solve = (data) => {
  const cases = data[0]
      , length = data.length
  let resultLines = [];
  for (let i = 1; i < length; i++){
    const [r, c, m] = data[i].split(" ").map(Number);
    const result = this.solveProblem(r, c, m);
    resultLines.push(`Case #${i}:`);
    if(result === "Impossible"){
      resultLines.push(result);
    }else {
      resultLines = resultLines.concat(result);
    }
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

readSolveWrite("C-small-practice.in", "C-small.out");
readSolveWrite("C-Large-practice.in", "C-large.out");
