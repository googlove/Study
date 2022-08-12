import javax.swing.table.AbstractTableModel;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Types;
import java.util.ArrayList;
import java.util.List;
import javax.swing.table.AbstractTableModel;

class MyDataModel extends AbstractTableModel{
    Integer[][] array=new Integer[3][3]; //Масив, в якому зберігаються дані, що будуть видні в таблиці
    public MyDataModel(){
        for (int i=0;i<3;i++)
            for (int j=0;j<3;j++)
                array[i][j]=new Integer(0);
    }
    public int getColumnCount() {return 3;}//В таблиці 3 стовпчика
    public int getRowCount() {return 3;} //В таблиці 3 рядка
    public boolean isCellEditable(int row, int column) { //Чи можна редагувати значення в комірках таблиці
        return true;
    }
    public Object getValueAt(int row,int col) { //Дані, що відображаються в таблиці
        return array[row][col];
    }
    public void setValueAt(Object value,int row,int col){ //Дані, що записуються в таблицю
        array[row][col]=new Integer((String)value);
    }
}