drop table d_transaksi cascade constraint purge;
drop table h_transaksi cascade constraint purge;
drop table membership cascade constraint purge;
drop table pegawai cascade constraint purge;
drop table fasilitas cascade constraint purge;
drop table kamar cascade constraint purge;
drop table jenis_kamar cascade constraint purge;
drop table booking cascade constraint purge;
drop table users cascade constraint purge;
drop table jabatan cascade constraint purge;

create table jenis_kamar(
kode_jenis varchar2(50),
nama_jenis varchar2(50),
harga_jenis number(20),
constraint pk_kode_jenis PRIMARY KEY (kode_jenis)
);

create table kamar(
id_kamar varchar2(50),
kode_jenis varchar2(50),
tersedia varchar2(50),
constraint pk_kamar PRIMARY KEY (id_kamar),
constraint fk_kamar foreign key(kode_jenis) references jenis_kamar(kode_jenis)
);

create table fasilitas(
id_fasilitas varchar2(50),
nama_fasilitas varchar2(50),
harga_fasilitas number(20),
deskripsi varchar2(50),
constraint pk_fasilitas PRIMARY KEY (id_fasilitas)
);


create table pegawai(
id_pegawai varchar2(50),
nama_pegawai varchar2(50),
jenis_kelamin varchar2(50),
jabatan varchar2(50),
alamat varchar2(50),
constraint pk_pegawai PRIMARY KEY (id_pegawai)
);

create table membership(
id_membership varchar2(50),
nama varchar2(50),
alamat varchar2(50),
no_telp varchar2(50),
email varchar2(50),
status number(10),
constraint pk_membership PRIMARY KEY (id_membership)
);

create table d_transaksi(
id_transaksi varchar2(50),
id_fasilitas varchar2(50),
constraint fk_fasilitas foreign key(id_fasilitas) references fasilitas(id_fasilitas)
);

create table h_transaksi(
id_transaksi varchar2(50),
id_kamar varchar2(50),
total_harga varchar2(50),
id_membership varchar2(50),
kode_booking varchar2(50),
tgl_checkin date,
tgl_checkout date,
constraint fk_fasilitas_kamar foreign key(id_kamar) references kamar(id_kamar),
constraint pk_transaksi PRIMARY KEY (id_transaksi)
);

create table booking(
kode_booking varchar2(50),
id_membership varchar2(50),
id_kamar varchar2(50),
tgl_msk date,
tgl_keluar date,
constraint pk_booking PRIMARY KEY (kode_booking),
constraint fk_booking foreign key(id_kamar) references kamar(id_kamar),
constraint fk_memberbooking foreign key(id_membership) references membership(id_membership)
);

create table users(
username varchar2(50),
password varchar2(50),
role varchar2(50),
constraint pk_user PRIMARY KEY (username)
);

create table jabatan(
nama_jabatan varchar2(50),
gaji_jabatan number,
constraint pk_jabatan PRIMARY KEY (nama_jabatan)
);
