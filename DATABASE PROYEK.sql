drop table d_transaksi;
drop table h_transaksi;
drop table membership;
drop table pegawai;
drop table fasilitas;
drop table kamar;
drop table jenis_kamar;

create table jenis_kamar(
kode_jenis varchar2(20),
nama_jenis varchar2(20),
harga_jenis number(20),
constraint pk_kode_jenis PRIMARY KEY (kode_jenis)
);

create table kamar(
id_kamar varchar2(20),
kode_jenis varchar2(20),
tersedia varchar2(20),
tgl_checkin date,
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


create table pegawai(
id_pegawai varchar2(20),
nama_pegawai varchar2(20),
jenis_kelamin varchar2(20),
jabatan varchar2(20),
alamat varchar2(20),
constraint pk_pegawai PRIMARY KEY (id_pegawai)
);

create table membership(
id_membership varchar2(30),
nama varchar2(30),
alamat varchar2(30),
no_telp varchar2(30),
email varchar2(30),
constraint pk_membership PRIMARY KEY (id_membership)
);

create table d_transaksi(
id_transaksi varchar2(20),
id_kamar varchar2(20),
id_fasilitas varchar2(20),
constraint fk_fasilitas_kamar foreign key(id_kamar) references kamar(id_kamar),
constraint fk_fasilitas foreign key(id_fasilitas) references fasilitas(id_fasilitas)
);

create table h_transaksi(
id_transaksi varchar2(20),
total_harga varchar2(20),
id_membership varchar2(20),
id_ref varchar2(20),
tgl_checkout date,
constraint pk_transaksi PRIMARY KEY (id_transaksi)
);

