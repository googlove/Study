# 1.
from math import ceil
print('Задача №1:')
print('Введіть n символів:')
n = int(input())
print('Введіть k символів:')
k = int(input())
print('Введіть s паролів/сек:')
s = int(input())
print('Введіть m паролів:')
m = int(input())
print('Введіть v секунд:')
v = int(input())
c = pow(n, k) / s
res = c + c * v / m
print(ceil(res / 3600))
print('Наступна задача')

# 2.
from math import log, ceil
print('Задача №2:')
print('Введіть n символів:')
n = int(input())
print('Введіть t років:')
t = int(input()) * 365 * 24 * 3600
print('Введіть s паролів в секунду:')
s = int(input())
res = (ceil(log(t * s, 52)))
print(res)
print('Наступна задача')

# 3.
from math import ceil
print('Задача №3:')
print('Введіть k символів:')
k = int(input())
print('Введіть t років:')
t = int(input()) * 365 * 24 * 3600
print('Введіть s паролів в сек:')
s = int(input())
res = int(input(ceil(pow(t * s, 1 / k))))
print(res)
print('Завершення задач')
