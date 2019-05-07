drop trigger tambah_jenis_kamar;
drop trigger tambah_kamar;
drop trigger tambah_fasilitas;

--tambah jenis kamar
create or replace trigger tambah_jenis_kamar
before insert
on jenis_kamar
for each row
declare
	jenis varchar2(20);
begin
	:new.kode_jenis:=AUTO_GEN_JENIS_KAMAR(:new.nama_jenis);
end;
/
show err;

--tambah kamar
create or replace trigger tambah_kamar
before insert
on kamar
for each row
declare
	jenis varchar2(20);
begin
	:new.id_kamar:=AUTO_GEN_KAMAR();
end;
/
show err;

--tambah fasilitas
create or replace trigger tambah_fasilitas
before insert
on fasilitas
for each row
declare
	jenis varchar2(20);
begin
	:new.id_fasilitas:=AUTO_GEN_FASILITAS();
end;
/
show err;