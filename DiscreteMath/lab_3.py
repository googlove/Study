from random import randint
import pprint
from numpy.linalg import matrix_power
b = list()
m, n = 10, 10
A = [[0, 1, 1, 1, 0],
     [1, 0, 0, 0, 1],
     [1, 0, 0, 1, 1],
     [1, 0, 1, 0, 1],
     [0, 1, 1, 1, 0]]
pprint.pprint(A)
E = [[1, 0, 0, 0, 0],
     [0, 1, 0, 0, 0],
     [0, 0, 1, 0, 0],
     [0, 0, 0, 1, 0],
     [0, 0, 0, 0, 1]]

m = matrix_power(A, 2)
print('A^2\n', m,"\n")
k = matrix_power(A, 3)
print('A^3\n', k)
n = matrix_power(A, 4)
print('A^4\n', k)
M = A + m + k + E
print('M = \n', M)