"use strict";

const expect = require("chai").expect;
const cookieClickerAlpha = require("./cookie-clicker-alpha");

describe("timeToBuyFarm(currentCookiesPerSecond, farmCost)", () =>{
  it("returns how long to buy a farm", () =>
  {
    let result = cookieClickerAlpha.timeToBuyFarm(2, 500);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(250);

    result = cookieClickerAlpha.timeToBuyFarm(6, 500);
    expect(Math.round( result * 10000000 ) / 10000000).to.equal(83.3333333);

  });
});
