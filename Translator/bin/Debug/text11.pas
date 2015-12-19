program test7;

var
  masInt: array [0..10] of integer;
  masReal: array [0..10] of real;
  masString: array [0..10] of string;
  stInt, ndInt, i: integer;
  stReal, ndReal: real;
  stString, ndString: string;

begin
stInt:=stInt+1;
  for i := 0 to 10 do
  begin
    masReal[i] := 10.0;
	stInt:=stInt+1;
    masReal[i] := masReal[i] / 4;
    masReal[i] := masReal[i] * 4;
    masReal[i] := (5 * 4 / 20 + (2 - 1));
    masString[i] := 'abv';
	i:=i+1;
  end;
  stInt:=stInt+1;
end.
