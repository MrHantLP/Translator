program testall;

const
  constanta = 100;

var
  masInt: array [0..10] of integer;
  masReal: array [0..10] of real;
  masString: array [0..10] of string;
  stInt, ndInt, i: integer;
  stReal, ndReal: real;
  stString, ndString: string;

begin
  for i := 0 to 10 do 
  begin
    masInt[i] := masInt[i] + constanta;
    masReal[i] := 10;
    masReal[i] := masReal[i] / 4;
    masReal[i] := masReal[i] * 4;
    masReal[i] := (5 * 4 / 20 - (2 - 1));
    masString[i] := 'abv';
  end;
  if masInt[5] = 0 then
  begin
    writeln(masInt[5]);
    writeln(masReal[5]);
  end
  else
    writeln(masString[5]);
  if masInt[5] <> 0 then
    writeln(masString[5]);
  ndInt := 5;
  while (stInt < 10) and (ndInt > 0) do 
  begin
    stInt := stInt + 4;
    ndInt := ndInt - 3;
  end;
  writeln(stInt, ' ', ndInt);
  stInt := stInt + constanta;
  writeln(stInt);
  while (ndReal >= 10) or (stReal <= 10) do 
  begin
    ndReal := ndReal + 1;
    stReal := stReal + 2;
  end;
  writeln(ndReal, ' ', stReal);
  stInt := 0;
  ndInt := 0;
  if stInt >= 0 then
    while stInt < 10 do 
    begin
      for i := 5 downto 0 do
        stInt := stInt + 2;
      stInt := stInt - 1;
    end
  else begin
    ndInt := 100;
    writeln(ndInt);
  end;
  writeln(stInt);
  stReal := 10 mod 4;
  writeln(stReal);
  stReal := 10 div 3;
  writeln(stReal);
  writeln();
  readln();
end.
