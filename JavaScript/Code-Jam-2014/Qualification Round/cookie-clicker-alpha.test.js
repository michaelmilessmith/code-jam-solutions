"use strict";

const expect = require("chai").expect;
const cookieClickerAlpha = require("./cookie-clicker-alpha");

describe("Cookie Clicker Alpha", () => {
  it("should match example tests", () => {
    let result = cookieClickerAlpha.solveProblem(2.0, 30.0, 1.0, 2.0);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(1.0000000);

    result = cookieClickerAlpha.solveProblem(2.0, 30.0, 2.0, 100.0);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(39.1666667);

    result = cookieClickerAlpha.solveProblem(2.0, 30.50000, 3.14159, 1999.19990);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(63.9680013);

    result = cookieClickerAlpha.solveProblem(2.0, 500.0, 4.0, 2000.0);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(526.1904762);

    result = cookieClickerAlpha.solveProblem(2.0, 1.03397, 99.87614, 99999.03277);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(0.6518189);    
  });
});
