drop table transaksi CASCADE CONSTRAINT PURGE; 
drop table membership CASCADE CONSTRAINT PURGE; 
drop table pegawai CASCADE CONSTRAINT PURGE; 
drop table fasilitas_kamar CASCADE CONSTRAINT PURGE; 
drop table fasilitas CASCADE CONSTRAINT PURGE; 
drop table kamar CASCADE CONSTRAINT PURGE; 
drop table jenis_kamar CASCADE CONSTRAINT PURGE; 

create table jenis_kamar(
kode_jenis varchar2(20),
harga_kamar number(20),
constraint pk_kode_jenis PRIMARY KEY (kode_jenis)
);

create table kamar(
id_kamar varchar2(20),
kode_jenis varchar2(20),
tersedia varchar2(20),
constraint pk_kamar PRIMARY KEY (id_kamar),
constraint fk_kamar foreign key(kode_jenis) references jenis_kamar(kode_jenis)
);

create table fasilitas(
id_fasilitas varchar2(20),
nama_fasilitas varchar2(20),
harga_fasilitas number(20),
deskripsi varchar2(20),
constraint pk_fasilitas PRIMARY KEY (id_fasilitas)
);

create table fasilitas_kamar(
id_kamar varchar2(20),
id_fasilitas varchar2(20),
constraint fk_fasilitas_kamar foreign key(id_kamar) references kamar(id_kamar),
constraint fk_fasilitas foreign key(id_fasilitas) references fasilitas(id_fasilitas)
);

create table pegawai(
id_pegawai varchar2(20),
nama_pegawai varchar2(20),
jenis_kelamin varchar2(20),
jabatan varchar2(20),
alamat varchar2(20),
constraint pk_pegawai PRIMARY KEY (id_pegawai)
);

create table membership(
id_membership varchar2(20),
nama varchar2(20),
alamat varchar2(20),
no_telp varchar2(20),
email varchar2(20),
constraint pk_membership PRIMARY KEY (id_membership)
);

create table transaksi(
id_transaksi varchar2(20),
id_kamar varchar2(20),
total_harga varchar2(20),
id_membership varchar2(20),
id_ref varchar2(20),
tanggal_masuk date,
tanggal_keluar date,
constraint pk_transaksi PRIMARY KEY (id_transaksi),
constraint fk_transaksi_kamar foreign key(id_kamar) references kamar(id_kamar)
);