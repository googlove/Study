const data = [40018,35802,32671,31776,28921,
16108,16958,36269,27346,26466,22737,18751,
11967,12069,21885,17447,15374,14524,12319,7697,7684];

function smoothing (arr) {
    return (2/(arr.length + 1)).toFixed(2);
}

function arraySum(array){
    let sum = 0;
    for(var i = 0; i < array.length; i++){
        sum += array[i];
        }
    return sum;
}

function averageValue (arr){
    return (arraySum(arr)/arr.length).toFixed(2);
}

function firstMethod(arr) {
    let result = [];
    for(let i = 0; i < arr.length; i++){
        result.push(arr[i] * smoothing(arr) + (1 - smoothing(arr)) * averageValue(arr));
    }
    return result;
}

function secondMethod(arr) {
    let result = [];
    for(let i = 0; i < arr.length; i++){
        result.push(arr[i] * smoothing(arr) + (1 - smoothing(arr)) * arr[0]);
    }
    return result;
}

function toTable (arr) {
    let result = [];
    for (let i = 0; i<arr.length; i++){
        let item = [];
        item.push(firstMethod(data)[i].toFixed(2));
        result.push(item);
    }
    for (let i = 0; i<arr.length; i++){
        result[i].push(secondMethod(data)[i].toFixed(2));
    }
    return result;
}

const sumFirstMethod = ((arraySum(firstMethod(data)))/100).toFixed(2);
const sumSecondMethod = ((arraySum(secondMethod(data)))/100).toFixed(2);
console.log('0 - First method; \n1 - Second method;');
console.table(toTable(data));
console.log('Smmothing parameter:', smoothing(data));
console.log('Sum first method:', sumFirstMethod);