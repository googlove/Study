package com.flame4ost.ua;

import java.util.ArrayList;

public class CheckWords {
    public String getData(String first,String second){
        String[] firstWordsSet = first.split(" ");
        String[] secondWordsSet = second.split(" ");
        ArrayList<String> resultArray = new ArrayList<>();
        String result = "";
        for (String s : firstWordsSet) {
            for (String value : secondWordsSet) {
                if (s.equals(value)) {
                    resultArray.add(s + "; ");
                }
            }
        }
        for (String s : resultArray) {
            result += s;
            System.out.println(result);
        }
        return result;
    }
}
