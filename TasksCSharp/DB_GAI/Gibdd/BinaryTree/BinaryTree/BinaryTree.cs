using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree <T>:IEnumerable<T> where T:IComparable<T>
    {
        private BinaryTreeNode<T> _head;// корень
        private int _count; // количество элементов

        #region Method Add
        public void Add (T value)
        {
            if (_head == null) //когда нет корня
            {
                _head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            _count++;
        }
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            //Первый случай, когда значение добавляемого узла меньше, чем тукущего
            if (value.CompareTo(node.Value)<0)
            {
                //Если левый потомок отсутствует - добавляем его
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);//повторная итерация
                }
            }
            else
            {
                //Если правый потомок отсутсвует добавляем его
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        #endregion
        #region FindNode
        private BinaryTreeNode<T> FindWithParent (T value, out BinaryTreeNode<T> parent)
        {
            // Метод FindWithParent возвращает первый найденный узел. Если значение не 
            // найдено, метод возвращает Null. Так же возвращает родительский узел для
            // найденного значения
            BinaryTreeNode<T> current = _head;
            parent = null;
            while(current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    // Если искомое значение меньше значения текущего узла, переходим
                    // к левому потомку
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше значения текущего узла, переходим
                    // к правому потомку
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    //Искомый элемент не найден
                    break;
                }
            }
            return current;
        }
        #endregion
        public bool Contains (T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }
        public int Count
        {
            get { return _count; }
        }
        #region Remove
        public bool Remove (T value)
        {
            BinaryTreeNode <T> current;
            BinaryTreeNode<T> parent;
            //Поиск узла для удаления
            current = FindWithParent(value, out parent);
            if (current == null)
            {
                return false;
            }
            _count--;
            
            // 1-ый Вариант: Если удаляемый узел не имеет правого потомка
            if (current.Right == null)
            {
                // Удаляем корень
                if (parent == null)
                {
                    _head = current.Left;
                }

                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение узла родителя больше, чем значение удаляемого
                        // уззла - сделать левого потомка ткущего узла левым потомком
                        // родительского узла
                        parent.Left = current.Left;
                    }

                    else if (result < 0)
                    {
                        // Если значение узла родителя меньше, чем значение удаляемого
                        // уззла - сделать левого потомка ткущего узла правым потомком
                        // родительского узла
                        parent.Left = current.Right;
                    }
                }
            }
            // 2-ой Вариант: Если удаляемый узел имеет правого потомка, у 
            // которого нет левого потомка
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                // Удаляем корень
                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение узла родителя больше, чем значение удаляемого
                        // узла - сделать правого потомка текущего узла - левым потомком
                        // родительского узла
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // Если значение узла родителя меньше, чем значение удаляемого
                        // узла - сделать правого потомка текущего узла - правым потомком
                        // родительского узла
                        parent.Right = current.Right;

                    }
                }
            }
            // 3-ий Вариант: Если удаляемый узел имеет правого потомка, у 
            // которого есть левый потомок
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left;
                BinaryTreeNode<T> leftMostParent = current.Right;

                //Поиск крайнего левого потомка
                while(leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }
                // Правое поддерево крайнего левого узла становится левым поддеревом его родительского узла

                leftMostParent.Left = leftMost.Right;

                // Присваиваем крайнему левому узлу в качестве левого потомка - левый потомок удаляемого узла,
                // а в качестве правого потомка - правый потомок удаляемого узла

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение узла родителя больше, чем значение удаляемого
                        // узла - сделать левого крайнего потомка удаляемого узла (leftMost)
                        // - левым потомком его родителя (parent)
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        // Если значение узла родителя меньше, чем значение удаляемого
                        // узла - сделать левого крайнего потомка удаляемого узла (leftMost)
                        // - правым потомком его родителя (parent)
                        parent.Right = leftMost;
                    }
                }
            }
            return true;
        }
        #endregion
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)
            {
                //Сохраняем узел в стек
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;
                //При перемещении по дереву мы должны отслеживать к какому ледующему узлу перейти:
                // к левому или правому потомку
                bool goLeftNext = true;
                //Начало. Помещение корня дерева в стек
                stack.Push(current);
                while (stack.Count > 0)
                {
                    //Если мы переходим влево
                    if (goLeftNext)
                    {
                        //Запись всех левых потомков в стек
                        while(current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    //Возвращение самого левого потомка
                    yield return current.Value;
                    //Если у него есть правый потомок
                    if (current.Right != null)
                    {
                        current = current.Right;
                        //Если мы один раз переходим вправо, то должны
                        //опять осуществить проход по левой стороне
                        goLeftNext = true;
                    }
                    else
                    {
                        //Если правого потомка нет мы должны извлечь из стека
                        //родительский узел
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
    }
}
