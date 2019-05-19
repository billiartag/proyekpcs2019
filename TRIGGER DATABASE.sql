drop trigger tambah_jenis_kamar;
drop trigger tambah_kamar;
drop trigger tambah_fasilitas;
drop trigger tambah_pegawai;
drop trigger tambah_membership;
drop trigger tambah_booking;
tambah_booking
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

--tambah pegawai
create or replace trigger tambah_pegawai
before insert
on pegawai
for each row
declare
	jenis varchar2(20);
begin
	:new.id_pegawai:=AUTO_GEN_PEGAWAI();
end;
/
show err;

--tambah membership
create or replace trigger tambah_membership
before insert
on membership
for each row
declare
	jenis varchar2(20);
begin
	:new.id_membership:=AUTO_GEN_MEMBERSHIP();
end;
/
show err;

--tambah booking
create or replace trigger tambah_booking
before insert
on booking
for each row
declare
	jenis varchar2(20);
begin
	:new.kode_booking:=AUTO_GEN_BOOKING();
end;
/
show err;