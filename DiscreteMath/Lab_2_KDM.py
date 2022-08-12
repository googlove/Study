from random import sample
from itertools import combinations
class Binary_matrix:
    set_range = list()
    a_set_array = list()
    b_set_array = list()
    relation_array = list()
    binary_matrix_array = list()
    charasteristics_list = list()
    make = list()
    def __init__(self, set_size, max_number):
        self.set_size = set_size
        self.max_number = max_number
    def sort_by_reasing(self):
        sorted_array_a = list()
        sorted_array_b = list()
        for i in range(self.max_number + 1):
            for j in self.a_set_array:
                if (i == j):
                    sorted_array_a.append(j)
            for j in self.b_set_array:
                if (i == j):
                    sorted_array_b.append(j)
        self.a_set_array = sorted_array_a
        self.b_set_array = sorted_array_b
    def make(self):
        make = list()
        for i in range(self.set_size):
            for j in range(self.set_size):
                if (self.binary_matrix_array[i][j] == self.binary_matrix_array[j][i]):
                    make.append("Симетрія")
                else:
                    make.append("Асиметричність")
        if "Асиметричність" in make:
            print("Асиметричність")
        else:
            print("Симетричність")
    def make_2(self):
        sum_first_diagonal = 0
        for i in range(self.set_size):
            for j in range(self.set_size):
                sum_first_diagonal = sum(self.binary_matrix_array[i][i] for i in range(10))
        if sum_first_diagonal == 10:
            print("Pефлекcивність")
    def make_3(self):
        sum_first_diagonal = 0
        for i in range(self.set_size):
            for j in range(self.set_size):
                sum_first_diagonal = sum(self.binary_matrix_array[i][i] for i in range(10))
        if sum_first_diagonal == 0:
            print("Антирефлекcивність")
    def make_4(self):
        sum_first_diagonal = 0
        for i in range(self.set_size):
            for j in range(self.set_size):
                sum_first_diagonal = sum(self.binary_matrix_array[i][i] for i in range(10))
        if sum_first_diagonal == 10 and (self.binary_matrix_array[i][j] == self.binary_matrix_array[j][i]):
            print("Антисиметричність")
    def make_5(self):
        for i in range(len(self.relation_array)):
            if (i + 1 < len(self.relation_array)):
                if (not (self.relation_array[i][1] % self.relation_array[i + 1][0] == 0) and
                        (self.relation_array[i][0] % self.relation_array[i + 1][0] == 0)):
                    self.charasteristics_list.append("Антитранзитивність")
                    break
        if "Антитранзитивність" not in self.charasteristics_list:
            self.charasteristics_list.append("Транзитивність")
        print(self.charasteristics_list)
    def make_relation_n_matrix_array(self):
        for i in self.a_set_array:
            bin_nums = []
            for j in self.b_set_array:
                if (i == j ) :
                    self.relation_array.append((j, i))
                    
                    bin_nums.append(1)
                else:
                    bin_nums.append(0)
            self.binary_matrix_array.append(bin_nums)
    def print_matrix_n_relations(self):
        print("Relations = ", self.relation_array, "\n")    
        for i in range(self.set_size):
            for j in range(self.set_size):
                print(self.binary_matrix_array[i][j], end="   ")
            print()
binary_matrix = Binary_matrix(10, 20)
binary_matrix.set_range = range(1, binary_matrix.max_number + 1)
binary_matrix.a_set_array = sample(binary_matrix.set_range, binary_matrix.set_size)
binary_matrix.b_set_array = sample(binary_matrix.set_range, binary_matrix.set_size)
binary_matrix.sort_by_reasing()
binary_matrix.make_relation_n_matrix_array()
binary_matrix.print_matrix_n_relations()
binary_matrix.make()
binary_matrix.make_2()
binary_matrix.make_3()
binary_matrix.make_4()
binary_matrix.make_5()


