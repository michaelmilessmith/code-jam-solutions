'use strict';

var fs = require('fs');

const read = (fileName) => {
  return fs.readFileSync(fileName, 'utf-8').replace(/\r/g, '').split('\n').filter(String);
};

var dataSmall = read("B-small-practice.in");
var dataLarge = read("B-Large-practice.in");
