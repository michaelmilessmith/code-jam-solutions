"use strict";

const expect = require("chai").expect;
const magicTrick = require("./magic-trick");


describe("getMatchingNumbers(arrayOne, arrayTwo)", () =>{
  it("compares two arrays, with a single matching number and return it in an array", () =>
  {
    const rowOne = [5, 6, 7, 8],
          rowTwo = [9, 10, 7, 12];

    const result = magicTrick.getMatchingNumbers(rowOne, rowTwo);

    expect(result).to.deep.equal([7]);
    expect(result).to.deep.not.equal([6]);

  });
  it("compares two arrays, with a multiple matching numbers and return them in an array", () =>
  {
    const rowOne = [5, 6, 7, 8],
          rowTwo = [5, 6, 7, 8];

    const result = magicTrick.getMatchingNumbers(rowOne, rowTwo);

    expect(result).to.deep.equal([5, 6, 7, 8]);
    expect(result).to.deep.not.equal([6]);

  });
  it("compares two arrays, with a no matching numbers and return an empty array", () =>
  {
    const rowOne = [5, 6, 7, 8],
          rowTwo = [9, 10, 11, 12];

    const result = magicTrick.getMatchingNumbers(rowOne, rowTwo);

    expect(result).to.deep.equal([]);
    expect(result).to.deep.not.equal([6]);

  });
});

describe("getChosenRow(chosen, rows)", () => {
  it("returns an array matching the row chosen", ()=>{
    const lines = [
      "2",
      "1 2 3 4",
      "5 6 7 8",
      "9 10 11 12",
      "13 14 15 16"
    ];
    const [chosen, ...rows] = lines;
    const result = magicTrick.getChosenRow(parseInt(chosen), rows);

    expect(result).to.deep.equal([5, 6, 7, 8]);
    expect(result).to.deep.not.equal([9, 10, 11, 12]);
  });
});

describe("readProblem(lines)", () =>{
  it("reads the problem and returns the two chosen row as arrays", () => {
    const lines = [
      "2",
      "1 2 3 4",
      "5 6 7 8",
      "9 10 11 12",
      "13 14 15 16",
      "3",
      "1 2 3 4",
      "5 6 7 8",
      "9 10 11 12",
      "13 14 15 16"
    ];
    const { arrayOne, arrayTwo } = magicTrick.readProblem(lines);

    expect(arrayOne).to.deep.equal([5, 6, 7, 8]);
    expect(arrayTwo).to.deep.equal([9, 10, 11, 12]);
  });
});

describe("getResult(matchingArray)", () => {
  it("returns the matching value if only one exists", () => {
    const result = magicTrick.getResult([7]);
    expect(result).to.equal(7);
  });
  it("returns 'Bad magician!' if only more than one match exists", () => {
    const result = magicTrick.getResult([5, 6, 7, 8]);
    expect(result).to.equal("Bad magician!");
  });
  it("returns 'Volunteer cheated!' if no matches exist", () => {
    const result = magicTrick.getResult([]);
    expect(result).to.equal("Volunteer cheated!");
  });
});

describe("solveProblem(lines)", () => {
  it("solves the problem", () =>{
    const lines = [
      "2",
      "1 2 3 4",
      "5 6 7 8",
      "9 10 11 12",
      "13 14 15 16",
      "3",
      "1 2 5 4",
      "3 11 6 15",
      "9 10 7 12",
      "13 14 8 16"
    ];
    const result = magicTrick.solveProblem(lines);
    expect(result).to.equal(7);
  });
});
