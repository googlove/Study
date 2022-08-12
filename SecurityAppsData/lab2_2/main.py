import math
text = 'ГогуловЯрославВолодимировичКолісникІванВалерійович'
m = 10
matr=[]
for i in range((n := math.ceil( len(text)/m))):
    matr.append(text[i*m: i*m+m].ljust(m,'о'))
word_len = 5
res = ''
for j in range(m):
    for i in range(n):
        res += matr[i][j]
        if (i+j*n+1) % word_len == 0:
            res += ' '
print(res)