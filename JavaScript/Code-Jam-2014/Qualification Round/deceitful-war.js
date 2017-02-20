'use strict'

exports.naomiWarResult = (naomiBlocks, kenBlocks) => {
  const naomiBlocksSorted = naomiBlocks.sort().reverse()
      , kenBlocksSorted = kenBlocks.sort().reverse();
  let naomiPoints = 0;
  for(let k = 0, n = 0; k < kenBlocks.length && n < naomiBlocks.length; k++){
    const index = naomiBlocksSorted.slice(n).findIndex(b => b < kenBlocksSorted[k]);
    naomiPoints += index;
    n += index + 1;
  }
  return naomiPoints;
}

exports.naomiDeceitfulWarResult = (naomiBlocks, kenBlocks) => {
  const naomiBlocksSorted = naomiBlocks.sort()
      , kenBlocksSorted = kenBlocks.sort().reverse();
  let naomiPoints = 0;
  for(let k = 0, n = 0; k < kenBlocks.length && n < naomiBlocks.length; k++){
    const index = naomiBlocksSorted.findIndex(b => b > kenBlocksSorted[k]);
    if(index > -1)
    {
      naomiPoints++;
      naomiBlocksSorted[index] = 0;
    }
  }
  return naomiPoints;
}
