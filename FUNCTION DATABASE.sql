drop function AUTO_GEN_JENIS_KAMAR;
drop function AUTO_GEN_KAMAR;
drop function AUTO_GEN_FASILITAS;
drop function AUTO_GEN_PEGAWAI;
drop function AUTO_GEN_MEMBERSHIP;
drop function AUTO_GEN_BOOKING;
drop function JENIS_KAMAR_TERBANYAK;

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

--Function menentukan Jenis Kamar terbanyak
set serveroutput on;
create or replace function JENIS_KAMAR_TERBANYAK
(
	bulan in varchar2
)
return varchar2
is
	hasil varchar2(10000);
	maks number(10);
begin
	maks:=-1;
	for i in (
		select a.nama_jenis,count(a.nama_jenis) as jumlah
		from jenis_kamar a,kamar b,booking c
		where c.id_kamar=b.id_kamar and b.kode_jenis=a.kode_jenis and upper(to_char(c.tgl_msk,'MONTH'))=upper(rpad(bulan,9,' '))
		group by a.nama_jenis
	)
	loop
		if maks=i.jumlah then 
		hasil:=hasil || ' Dan ' || i.nama_jenis;
		maks:=i.jumlah;
		end if;
		
		if maks<i.jumlah then 
		hasil:=i.nama_jenis;
		maks:=i.jumlah;
		end if;
		
	end loop;
	return hasil;
end;
/
show err;

create or replace function TRANSAKSI_TERBANYAK
return varchar2
is
	hasil varchar2(10000);
	maks number(10);
begin
	maks:=-1;
	for i in (
		select to_char(tgl_checkin, 'MONTH') as bulan, count(*) as jumlah
		from h_transaksi
		group by to_char(tgl_checkin, 'MONTH')
	)
	loop
		if maks = i.jumlah then 
		hasil := hasil || ' dan ' || i.bulan;
		maks := i.jumlah;
		end if;
		
		if maks < i.jumlah then 
		hasil := i.bulan;
		maks := i.jumlah;
		end if;
	end loop;
	return hasil;
end;
/
show err;
