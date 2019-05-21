drop function AUTO_GEN_JENIS_KAMAR;
drop function AUTO_GEN_KAMAR;
drop function AUTO_GEN_FASILITAS;
drop function AUTO_GEN_PEGAWAI;
drop function AUTO_GEN_MEMBERSHIP;
drop function AUTO_GEN_BOOKING;

--auto gen jenis kamar
set serveroutput on;
create or replace function AUTO_GEN_JENIS_KAMAR
(
	jenis in varchar2
)
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='JK';
	
	select to_number(max(substr(kode_jenis,3,3))) into temp from jenis_kamar where upper(substr(kode_jenis,1,2))=upper(hasil);
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen kamar

set serveroutput on;
create or replace function AUTO_GEN_KAMAR
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='KA';
	select to_number(max(substr(id_kamar,3,3))) into temp from kamar;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen fasilitas

set serveroutput on;
create or replace function AUTO_GEN_FASILITAS
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='FA';
	select to_number(max(substr(id_fasilitas,3,3))) into temp from fasilitas;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen pegawai

set serveroutput on;
create or replace function AUTO_GEN_PEGAWAI
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='PE';
	select to_number(max(substr(id_pegawai,3,3))) into temp from pegawai;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen membership

set serveroutput on;
create or replace function AUTO_GEN_MEMBERSHIP
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='ME';
	select to_number(max(substr(id_membership,3,3))) into temp from membership;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen pegawai

set serveroutput on;
create or replace function AUTO_GEN_MEMBERSHIP
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='ME';
	select to_number(max(substr(id_membership,3,3))) into temp from membership;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;

--auto gen booking

set serveroutput on;
create or replace function AUTO_GEN_BOOKING
return varchar2
is
	hasil varchar2(30);
	counter number(7);
	cek number(5);
	temp number(5);
begin
	hasil:='KB';
	select to_number(max(substr(kode_booking,3,3))) into temp from booking;
	temp:=temp+1;
	
	if temp>0 then
	hasil:= upper(hasil)||lpad(temp,3,'0');
	else
	hasil:= upper(hasil)||lpad('1',3,'0');
	end if;
	return hasil;
end;
/
show err;
