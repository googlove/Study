uses crt;
type mnz=set of byte;
const n=40;
      m=20;
procedure init(var mn:mnz);
var i,k:byte;
begin
mn:=[];
for i:=1 to m do
 begin
  repeat
  k:=1+random(n);
  until not(k in mn);
  mn:=mn+[k];
 end;
end;
procedure print(mn:mnz;c:string);
var i:byte;
begin
writeln('Множина ',c);
for i:=1 to n do
if i in mn then write(i:4);
writeln
end;
var x,a,b,c,a1,res:mnz;
    i,k:byte;
begin
randomize;
x:=[1..n];
init(a);
init(b);
init(c);
print(x,'x');
print(a,'A');
print(b,'B');
print(c,'C');
a1:=(b-c);
print(a1,'A1');
res:=a*a1;
print(res,'A*(B-C)');
end.