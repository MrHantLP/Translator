program primer1;
var s1,s2:string;
    i:integer;
	a: array [1..10] of integer;
begin
    readln(s1); s2:='';
    for i:=20 downto 1 do begin
       s2:=s2+s1[i];
	   i:=i mod 2;
    end;
    if s1=s2 then writeln(s1, 'папа - perevertish')
             else  writeln(s1, ' - ne perevertish');
end.