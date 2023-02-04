n=int(input("Enter a number:"))
p=int(input("Enter a number:"))
f = True
i = n
count = 0
while i>0:
  m=i%10
  if m==p:
      f = False
      count=count+1 
  i=i//10

       
if f:
  print ("Numbers" , p , "in Numbers" , n , "there is no")
    
else:
  print("Number" , p, "in Number" , n, "is present")
  print("Number of repetitions:", count)
