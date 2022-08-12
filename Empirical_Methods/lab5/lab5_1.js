const array = [40018,35802,32671,31776,28921,
    16108,16958,36269,27346,26466,22737,18751,
    11967,12069,21885,17447,15374,14524,12319,7697,7684];

    //Кількість повторень
    const newArray = array.map((el)=>el / 1000);


    let result = {};
    for (let i = 0; i < newArray.length; ++i)
    {
        let a = newArray[i];
        if (result[a] != undefined)
            ++result[a];
        else
            result[a] = 1;
    }
    for (let key in result){
        console.log("Значення показника", '\n', 'Число ' + key);
    }
    console.log("______________________________________________________");

    //Параметр згладжування

    const par = 2 / (21 + 1);
    console.log("Параметр згладжування =", par.toFixed(2));

    //Екпонеціальне згладження
    const res1 = newArray.reduce(function(sum, elem) {
        return sum + elem / 21;
    }, 0);
    console.log("Екпонеціальне згладження для показника 1 першого способу =",res1.toFixed(2));

    const res2 = (newArray[0] * par) + (1 - par) * res1;
    console.log("Екпонеціальне згладження для показника 2 першого способу =",res2.toFixed(2));

    const res3 = (newArray[1] * par) + (1 - par) * res2;
    console.log("Екпонеціальне згладження для показника 3 першого способу =",res3.toFixed(2));

    const res4 = (newArray[2] * par) + (1 - par) * res3;
    console.log("Екпонеціальне згладження для показника 4 першого способу =",res4.toFixed(2));

    const res5 = (newArray[3] * par) + (1 - par) * res4;
    console.log("Екпонеціальне згладження для показника 5 першого способу =",res5.toFixed(2));

    const res6 = (newArray[4] * par) + (1 - par) * res5;
    console.log("Екпонеціальне згладження для показника 6 першого способу =",res6.toFixed(2));

    const res7 = (newArray[5] * par) + (1 - par) * res6;
    console.log("Екпонеціальне згладження для показника 7 першого способу =",res7.toFixed(2));

    const res8 = (newArray[6] * par) + (1 - par) * res7;
    console.log("Екпонеціальне згладження для показника 8 першого способу =",res8.toFixed(2));

    const res9 = (newArray[7] * par) + (1 - par) * res8;
    console.log("Екпонеціальне згладження для показника 9 першого способу =", Math.abs(res9).toFixed(2));

    const res10 = (newArray[8] * par) + (1 - par) * res9;
    console.log("Екпонеціальне згладження для показника 10 першого способу =",res10.toFixed(2));

    const res11 = (newArray[9] * par) + (1 - par) * res10;
    console.log("Екпонеціальне згладження для показника 11 першого способу =",res11.toFixed(2));

    const res12 = (newArray[10] * par) + (1 - par) * res11;
    console.log("Екпонеціальне згладження для показника 12 першого способу =",res12.toFixed(2));

    const res13 = (newArray[11] * par) + (1 - par) * res12;
    console.log("Екпонеціальне згладження для показника 13 першого способу =",res13.toFixed(2));

    const res14 = (newArray[12] * par) + (1 - par) * res13;
    console.log("Екпонеціальне згладження для показника 14 першого способу =",res14.toFixed(2));

    const res15 = (newArray[13] * par) + (1 - par) * res14;
    console.log("Екпонеціальне згладження для показника 15 першого способу =",res15.toFixed(2));

    const res16 = (newArray[14] * par) + (1 - par) * res15;
    console.log("Екпонеціальне згладження для показника 16 першого способу =",res16.toFixed(2));

    const res17 = (newArray[15] * par) + (1 - par) * res16;
    console.log("Екпонеціальне згладження для показника 17 першого способу =",res17.toFixed(2));

    const res18 = (newArray[16] * par) + (1 - par) * res17;
    console.log("Екпонеціальне згладження для показника 18 першого способу =",res18.toFixed(2));

    const res19 = (newArray[17] * par) + (1 - par) * res18;
    console.log("Екпонеціальне згладження для показника 19 першого способу =",res19.toFixed(2));

    const res20 = (newArray[18] * par) + (1 - par) * res19;
    console.log("Екпонеціальне згладження для показника 20 першого способу =",res20.toFixed(2));

    const res21 = (newArray[19] * par) + (1 - par) * res20;
    console.log("Екпонеціальне згладження для показника 21 першого способу =",res21.toFixed(2));
    console.log("_______________________________________________________");

    //Екпонеціальне згладження 2 спосіб
    const result1 = newArray[0];
    console.log("Екпонеціальне згладження для показника 1 другого способу =", result1.toFixed(2));

    const result2 = (newArray[0] * par) + (1 - par) * newArray[0];
    console.log("Екпонеціальне згладження для показника 2 другого способу =",result2.toFixed(2));

    const result3 = (newArray[1] * par) + (1 - par) * result2;
    console.log("Екпонеціальне згладження для показника 3 другого способу =",result3.toFixed(2));

    const result4 = (newArray[2] * par) + (1 - par) * result3;
    console.log("Екпонеціальне згладження для показника 4 другого способу =",result4.toFixed(2));

    const result5 = (newArray[3] * par) + (1 - par) * result4;
    console.log("Екпонеціальне згладження для показника 5 другого способу =",result5.toFixed(2));

    const result6 = (newArray[4] * par) + (1 - par) * result5;
    console.log("Екпонеціальне згладження 6 другого способу =",result6.toFixed(2));

    const result7 = (newArray[5] * par) + (1 - par) * result6;
    console.log("Екпонеціальне згладження для показника 7 другого способу =",result7.toFixed(2));

    const result8 = (newArray[6] * par) + (1 - par) * result7;
    console.log("Екпонеціальне згладження для показника 8 другого способу =",result8.toFixed(2));

    const result9 = (newArray[7] * par) + (1 - par) * result8;
    console.log("Екпонеціальне згладження для показника 9 другого способу =",result9.toFixed(2));

    const result10 = (newArray[8] * par) + (1 - par) * result9;
    console.log("Екпонеціальне згладження для показника 10 другого способу =",result10.toFixed(2));

    const result11 = (newArray[9] * par) + (1 - par) * result10;
    console.log("Екпонеціальне згладження для показника 11 другого способу =",result11.toFixed(2));

    const result12 = (newArray[10] * par) + (1 - par) * result11;
    console.log("Екпонеціальне згладження для показника 12 другого способу =",result12.toFixed(2));

    const result13 = (newArray[11] * par) + (1 - par) * result12;
    console.log("Екпонеціальне згладження для показника 13 другого способу =",result13.toFixed(2));

    const result14 = (newArray[12] * par) + (1 - par) * result13;
    console.log("Екпонеціальне згладження для показника 14 другого способу =",result14.toFixed(2));

    const result15 = (newArray[13] * par) + (1 - par) * result14;
    console.log("Екпонеціальне згладження для показника 15 другого способу =",result15.toFixed(2));

    const result16 = (newArray[14] * par) + (1 - par) * result15;
    console.log("Екпонеціальне згладження для показника 16 другого способу =",result16.toFixed(2));

    const result17 = (newArray[15] * par) + (1 - par) * result16;
    console.log("Екпонеціальне згладження для показника 17 другого способу =",result17.toFixed(2));

    const result18 = (newArray[16] * par) + (1 - par) * result17;
    console.log("Екпонеціальне згладження для показника 18 другого способу =",result18.toFixed(2));

    const result19 = (newArray[17] * par) + (1 - par) * result18;
    console.log("Екпонеціальне згладження для показника 19 другого способу =",result19.toFixed(2));

    const result20 = (newArray[18] * par) + (1 - par) * result19;
    console.log("Екпонеціальне згладження для показника 20 другого способу =",result20.toFixed(2));

    const result21 = (newArray[19] * par) + (1 - par) * result20;
    console.log("Екпонеціальне згладження для показника 21 другого способу =",result21.toFixed(2));
    console.log("______________________________________________________");
    // прогноз
    const prognoz22 = (newArray[20] * par) + (1 - par) * res21;
    console.log("Прогноз на 22 день для 1 способу =", prognoz22.toFixed(2));

    const prognoz22_2 = (newArray[20] * par) + (1 - par) * result21;
    console.log("Прогноз на 22 день для 2 способу =", prognoz22_2.toFixed(2));
    console.log("______________________________________________________");

    //Середня відносна помилка

    const sp2 = (newArray[0] - result1) / newArray[0] * 100;
    console.log("Середня відносна помилка для 1 показника 1 cпособу =", sp2.toFixed(2));

    const sp3 = (newArray[1] -	res2) / newArray[1] * 100;
    console.log("Середня відносна помилка для 2 показника 1 cпособу =", sp3.toFixed(2));

    const sp4 = (newArray[2] -	res3) / newArray[2] * 100;
    console.log("Середня відносна помилка для 3 показникам 1 cпособу =", sp4.toFixed(2));

    const sp5 = (newArray[3] -	res4) / newArray[3] * 100;
    console.log("Середня відносна помилка для 4 показника 1 cпособу =", sp5.toFixed(2));

    const sp6 = (newArray[4] -	res5) / newArray[4] * 100;
    console.log("Середня відносна помилка для 5 показника 1 cпособу =", sp6.toFixed(2));

    const sp7 = (newArray[5] -	res6) / newArray[5] * 100;
    console.log("Середня відносна помилка для 6 показника 1 cпособу =", Math.abs(sp7).toFixed(2));

    const sp8 = (newArray[6] -	res7) / newArray[6] * 100;
    console.log("Середня відносна помилка для 7 показника 1 cпособу =", Math.abs(sp8).toFixed(2));

    const sp9 = (newArray[7] -	res8) / newArray[7] * 100;
    console.log("Середня відносна помилка для 8 показника 1 cпособу =", Math.abs(sp9).toFixed(2));

    const sp10 = (newArray[8] -	res9) / newArray[8] * 100;
    console.log("Середня відносна помилка для 9 показника 1 cпособу =", sp10.toFixed(2));

    const sp11 = (newArray[9] -	res10) / newArray[9] * 100;
    console.log("Середня відносна помилка для 110 показника 1 cпособу =", sp11.toFixed(2));

    const sp12 = (newArray[10] -	res11) / newArray[10] * 100;
    console.log("Середня відносна помилка для 11 показника 1 cпособу =", Math.abs(sp12).toFixed(2));

    const sp13 = (newArray[11] -	res12) / newArray[11] * 100;
    console.log("Середня відносна помилка для 12 показника 1 cпособу =", Math.abs(sp13).toFixed(2));

    const sp14 = (newArray[12] -	res13) / newArray[12] * 100;
    console.log("Середня відносна помилка для 13 показника 1 cпособу =", Math.abs(sp14).toFixed(2));

    const sp15 = (newArray[13] -	res14) / newArray[13] * 100;
    console.log("Середня відносна помилка для 14 показника 1 cпособу =", Math.abs(sp15).toFixed(2));

    const sp16 = (newArray[14] -	res15) / newArray[14] * 100;
    console.log("Середня відносна помилка для 15 показника 1 cпособу =", Math.abs(sp16).toFixed(2));

    const sp17 = (newArray[15] -	res16) / newArray[15] * 100;
    console.log("Середня відносна помилка для 16 показника 1 cпособу =", Math.abs(sp17).toFixed(2));

    const sp18 = (newArray[16] -	res17) / newArray[16] * 100;
    console.log("Середня відносна помилка для 17 показника 1 cпособу =", Math.abs(sp18).toFixed(2));

    const sp19 = (newArray[17] -	res18) / newArray[17] * 100;
    console.log("Середня відносна помилка для 18 показника 1 cпособу =", Math.abs(sp19).toFixed(2));

    const sp20 = (newArray[18] -	res19) / newArray[18] * 100;
    console.log("Середня відносна помилка для 19 показника 1 cпособу =", Math.abs(sp20).toFixed(2));

    const sp21 = (newArray[19] -	res20) / newArray[19] * 100;
    console.log("Середня відносна помилка для 20 показника 1 cпособу =", Math.abs(sp21).toFixed(2));

    const sp22 = (newArray[20] -	res21) / newArray[20] * 100;
    console.log("Середня відносна помилка для 21 показника 1 cпособу =", Math.abs(sp22).toFixed(2));

    console.log("___________________________________________________________________________")
    const spb2 = (newArray[0] - result1) / newArray[0] * 100;
    console.log("Середня відносна помилка для 1 показника 1 cпособу =", spb2.toFixed(2));

    const spb3 = (newArray[1] -	result2) / newArray[1] * 100;
    console.log("Середня відносна помилка для 2 показника 1 cпособу =", Math.abs(spb3).toFixed(2));

    const spb4 = (newArray[2] -	result3) / newArray[2] * 100;
    console.log("Середня відносна помилка для 3 показникам 1 cпособу =", Math.abs(spb4).toFixed(2));

    const spb5 = (newArray[3] -	result4) / newArray[3] * 100;
    console.log("Середня відносна помилка для 4 показника 1 cпособу =", Math.abs(spb5).toFixed(2));

    const spb6 = (newArray[4] -	result5) / newArray[4] * 100;
    console.log("Середня відносна помилка для 5 показника 1 cпособу =", Math.abs(spb6).toFixed(2));

    const spb7 = (newArray[5] -	result6) / newArray[5] * 100;
    console.log("Середня відносна помилка для 6 показника 1 cпособу =", Math.abs(spb7).toFixed(2));

    const spb8 = (newArray[6] -	result7) / newArray[6] * 100;
    console.log("Середня відносна помилка для 7 показника 1 cпособу =", Math.abs(spb8).toFixed(2));

    const spb9 = (newArray[7] -	result8) / newArray[7] * 100;
    console.log("Середня відносна помилка для 8 показника 1 cпособу =", spb9.toFixed(2));

    const spb10 = (newArray[8] -	result9) / newArray[8] * 100;
    console.log("Середня відносна помилка для 9 показника 1 cпособу =", Math.abs(spb10).toFixed(2));

    const spb11 = (newArray[9] -	result10) / newArray[9] * 100;
    console.log("Середня відносна помилка для 110 показника 1 cпособу =", Math.abs(spb11).toFixed(2));

    const spb12 = (newArray[10] -	result11) / newArray[10] * 100;
    console.log("Середня відносна помилка для 11 показника 1 cпособу =", Math.abs(spb12).toFixed(2));

    const spb13 = (newArray[11] -	result12) / newArray[11] * 100;
    console.log("Середня відносна помилка для 12 показника 1 cпособу =", Math.abs(spb13).toFixed(2));

    const spb14 = (newArray[12] -	result13) / newArray[12] * 100;
    console.log("Середня відносна помилка для 13 показника 1 cпособу =", Math.abs(spb14).toFixed(2));

    const spb15 = (newArray[13] -	result14) / newArray[13] * 100;
    console.log("Середня відносна помилка для 14 показника 1 cпособу =", Math.abs(spb15).toFixed(2));

    const spb16 = (newArray[14] -	result15) / newArray[14] * 100;
    console.log("Середня відносна помилка для 15 показника 1 cпособу =", Math.abs(spb16).toFixed(2));

    const spb17 = (newArray[15] -	result16) / newArray[15] * 100;
    console.log("Середня відносна помилка для 16 показника 1 cпособу =", Math.abs(spb17).toFixed(2));

    const spb18 = (newArray[16] -	result17) / newArray[16] * 100;
    console.log("Середня відносна помилка для 17 показника 1 cпособу =", Math.abs(spb18).toFixed(2));

    const spb19 = (newArray[17] -	result18) / newArray[17] * 100;
    console.log("Середня відносна помилка для 18 показника 1 cпособу =", Math.abs(spb19).toFixed(2));

    const spb20 = (newArray[18] -	result19) / newArray[18] * 100;
    console.log("Середня відносна помилка для 19 показника 1 cпособу =", Math.abs(spb20).toFixed(2));

    const spb21 = (newArray[19] -	result20) / newArray[19] * 100;
    console.log("Середня відносна помилка для 20 показника 1 cпособу =", Math.abs(spb21).toFixed(2));

    const spb22 = (newArray[20] -	result21) / newArray[20] * 100;
    console.log("Середня відносна помилка для 21 показника 1 cпособу =", Math.abs(spb22).toFixed(2));

        //сума
    const sum1 = (sp2 + sp3 + sp4 + sp5 + sp6 + sp7 + sp8 + sp9 + sp10 + sp11 + sp12 + sp13 + sp14 + sp15 + sp16 + sp17 + sp18 + sp19 + sp20 + sp21 + sp22).toFixed(2);
    console.log("Сума середньої відносної помилки 1 способу =", Math.abs(sum1));

    const sum2 = (spb2 + spb3 + spb4 + spb5 + spb6 + spb7 + spb8 + spb9 + spb10 + spb11 + spb12 + spb13 + spb14 + spb15 + spb16 + spb17 + spb18 + spb19 + spb20 + spb21 + spb22).toFixed(2);
    console.log("Сума середньої відносної помилки 2 способу =",Math.abs(sum2));

    const e = sum1 / 100;
    const e2 = sum2 / 100;
    
    console.log("Середня відносна помилка для 1 способу =", Math.abs(e).toFixed(2));
    console.log("Середня відносна помилка для 2 способу =", Math.abs(e2).toFixed(2))
    