package com.flame4ost.ua;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Main {

    public static void main(String[] args) {
        CheckWords checkWords = new CheckWords();
        JPanel mainPanel = new JPanel();
        JFrame frame = new JFrame("Lab1");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(535, 300);
        JLabel firstLabel = new JLabel("Перший рядок");
        JTextField firstQuoteString = new JTextField(40);
        JLabel secondLabel = new JLabel("Другий рядок");
        JTextField secondQuoteString = new JTextField(40);
        JLabel thirdLabel = new JLabel(" , Спільні символи:");
        JTextField similarWordsString = new JTextField(40);
        JButton submit = new JButton("Пошук спільних слів");
        submit.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                String firstString = firstQuoteString.getText();
                String secondString = secondQuoteString.getText();
                similarWordsString.setText(checkWords.getData(firstString, secondString));
            }
        });
        JLabel info = new JLabel("Лабораторна робота №1 з дисципліни 'Архітектура моделювання та програмування ПЗ' ");
        JLabel studentInfo = new JLabel("Виконав: студент гр. ПЗС-1944 Гогулов Я.В. ");
        JLabel teacherInfo = new JLabel("Перевірив: викладач кафедри ПЗАС Куницька С.Ю. ");
        mainPanel.add(firstLabel);
        mainPanel.add(firstQuoteString);
        mainPanel.add(secondLabel);
        mainPanel.add(secondQuoteString);
        mainPanel.add(submit);
        mainPanel.add(thirdLabel);
        mainPanel.add(similarWordsString);
        mainPanel.add(info);
        mainPanel.add(studentInfo);
        mainPanel.add(teacherInfo);
        frame.getContentPane().add(BorderLayout.CENTER, mainPanel);
        frame.setVisible(true);
    }
}

