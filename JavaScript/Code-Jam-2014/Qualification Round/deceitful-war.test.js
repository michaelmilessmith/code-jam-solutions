"use strict";

const expect = require("chai").expect;
const solver = require("./deceitful-war");

describe("Deceitful War", () =>
{
  it("returns the points Naomi scores if she plays war optimally", () =>
  {
    const result0 = solver.naomiWarResult([0.5], [0.6]);
    expect(result0).to.equal(0);

    const result1 = solver.naomiWarResult([0.7, 0.2], [0.8, 0.3]);
    expect(result1).to.equal(0);

    const result2 = solver.naomiWarResult([0.5, 0.1, 0.9], [0.6, 0.4, 0.3]);
    expect(result2).to.equal(1);

    const result3 = solver.naomiWarResult(
      [0.186, 0.389, 0.907, 0.832, 0.959, 0.557, 0.300, 0.992, 0.899],
      [0.916, 0.728, 0.271, 0.520, 0.700, 0.521, 0.215, 0.341, 0.458]);
    expect(result3).to.equal(4);
  });
  it("returns the points Naomi scores if she plays deceitful war optimally", () =>
  {
    const result0 = solver.naomiDeceitfulWarResult([0.5], [0.6]);
    expect(result0).to.equal(0);

    const result1 = solver.naomiDeceitfulWarResult([0.7, 0.2], [0.8, 0.3]);
    expect(result1).to.equal(1);

    const result2 = solver.naomiDeceitfulWarResult([0.5, 0.1, 0.9], [0.6, 0.4, 0.3]);
    expect(result2).to.equal(2);

    const result3 = solver.naomiDeceitfulWarResult(
      [0.186, 0.389, 0.907, 0.832, 0.959, 0.557, 0.300, 0.992, 0.899],
      [0.916, 0.728, 0.271, 0.520, 0.700, 0.521, 0.215, 0.341, 0.458]);
    expect(result3).to.equal(8);
  });
});
