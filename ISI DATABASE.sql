--jenis kamar
insert into jenis_kamar values(' ','Luxury',500000);
--kamar
insert into kamar values(' ','JK001',null,'Y');
insert into kamar values(' ','JK001',null,'Y');
insert into kamar values(' ','JK001','ME001','N');
--fasilitas
insert into fasilitas values('','kolam renang',100000,'kolam renang');
--pegawai
insert into pegawai values('','Alfonsus Yves','L','ADMIN','mangrove');
insert into pegawai values('','Karyawan1','L','KOKI','somewhere over da rainbow');
insert into pegawai values('','mister satpam','L','SATPAM','emboh');
--membership
insert into membership values('','Alfonsus Yves','mangrove','081331322570','edwin0sidharta@gmail.com');
--booking
insert into booking values('','ME001','KA001',TO_DATE('15/05/2019', 'dd/mm/yyyy'),TO_DATE('19/05/2019', 'dd/mm/yyyy'));
--user
insert into users values('alfon','1','FRONT OFFICE');
insert into users values('manajer','1','MANAGER');
insert into users values('cust','1','CUSTOMER');
--jabatan
insert into jabatan values('KOKI',4000000);
insert into jabatan values('SATPAM',3000000);
--h trans
insert into h_transaksi values('TR001',3000000,'ME001','',TO_DATE('11/05/2019', 'dd/mm/yyyy'),TO_DATE('14/05/2019', 'dd/mm/yyyy'));
commit;

