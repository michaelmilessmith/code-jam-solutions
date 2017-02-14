"use strict";

const expect = require("chai").expect;
const cookieClickerAlpha = require("./cookie-clicker-alpha");

describe("Cookie Clicker Alpha", () => {
  it("should return how long to reach a target number of cookies", () => {
    let result = cookieClickerAlpha.timeToTarget(2, 500);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(250);

    result = cookieClickerAlpha.timeToTarget(6, 500);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(83.3333333);
  });
});
