"use strict";

const expect = require("chai").expect;
const solver = require("./minesweeper-master");

describe("Minesweeper Master", () => {
  it("should return results to match example tests", () => {
    const result0 = solver.solveProblem(5, 5, 23);
    expect(result0).to.equal("Impossible");

    const result1 = solver.solveProblem(3, 1, 1);
    expect(result1).to.deep.equal([["c"],["."],["*"]]);

    const result2 = solver.solveProblem(1, 5, 2);
    expect(result2).to.deep.equal([["c",".",".","*","*"]]);

    const result3 = solver.solveProblem(5, 5, 16);
    expect(result3).to.deep.equal([
      ["c",".",".","*","*"],
      [".",".",".","*","*"],
      [".",".",".","*","*"],
      ["*","*","*","*","*"],
      ["*","*","*","*","*"]
    ]);
  });
});
