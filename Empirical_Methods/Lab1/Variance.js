const array = [40018,35802,32671,31776,28921,
16108,16958,36269,27346,26466,22737,18751,
11967,12069,21885,17447,15374,14524,12319,7697,7684];

//Мінімальне і максимане число
  const max = Math.max(...array); 
  const min = Math.min(...array); 
  
  //Кількість повторень
  let result = {};
  for (let i = 0; i < array.length; ++i)
  {
      let a = array[i];
      if (result[a] != undefined)
          ++result[a];
      else
          result[a] = 1;
  }
  for (let key in result){
      console.log('Число ' + key + ' повторюється ' + result[key] + ' раз(а)');
  }
//Середнє арифментичне
const initialValue = 0;
const sum = array.reduce((previousValue, currentValue) => previousValue + currentValue, initialValue
);
console.log("Середнє арифметичне =", sum * 1 / 21);
//Показник розмаху варіації
const R = max - min;
console.log("Показник розмаху варіації =", R);

//Середнє лінійне відхилення
const sumXi_x = array => array.map(e => `Сума xi - x числа ${e} = ${sum - e}`).join('\n');
console.log(sumXi_x(array))

const d = (
  18361 + 
  14612 + 
  14145 + 
  11014 + 
  10119 + 
  7264 + 
  5689 + 
  4809 + 
  1080 + 
  228 + 
  2905 + 
  4209 + 
  4698 + 
  5548 + 
  6282 + 
  7132 + 
  9337 + 
  9587 + 
  9689 + 
  13959 + 
 13972) / 21;
console.log("Середнє лінійне відхилення =", d);
//Дисперсія 
const sum_for_S2 = (
1916442659 +
337140310 + 
213521677 + 
200091802 + 
121316587 + 
102401870 + 
52771230 + 
32369055 + 
23130145 + 
1167223 + 
52157 + 
8442622 + 
17720892 + 
22077020 + 
30787173 + 
39471302 + 
50874254 + 
87191129 + 
91922439 + 
93888717 + 
194870964 + 
195234083)
const S2 = Math.pow(sum_for_S2, 2) / 21;
console.log("Дисперсія =", S2);
