li=[40018,35802,32671,31776,28921,
16108,16958,36269,27346,26466,22737,18751,
11967,12069,21885,17447,15374,14524,12319,7697,7684]

#variable for storing average for each moving average
avg=0;
#initialize window, number of numbers whose average should be taken at a time
window=3
#print the header
print('Sr.No.'+'\t'+'Input numbers/Indicator'+ '\t'*(window-2) +'Moving Average')
print('-'*8*(window+2))
#loop till n-k+1 element
for i in range(len(li)-window+1):
    #print the moving average serial number
    print(' '+str(i+1), end='\t')
    
    #initialize average to 0
    avg=0
   
    #loop and add next window number of items
    for j in range(window):
        avg=avg+li[j+i]
        print(li[j+i], end='\t')
        
    #print the average over each iteration
    print("{:3.2f}".format(avg/window))
