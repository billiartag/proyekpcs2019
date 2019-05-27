--jenis kamar
insert into jenis_kamar values('','Luxury',500000);
insert into jenis_kamar values('','Deluxe',1000000);
--kamar
insert into kamar values(' ','JK001',null,'Y');
insert into kamar values(' ','JK002',null,'Y');
insert into kamar values(' ','JK001','ME001','N');
--fasilitas
insert into fasilitas values('','kolam renang',100000,'kolam renang');
insert into fasilitas values('','spa',500000,'spa');
--pegawai
insert into pegawai values('','Alfonsus Yves','L','FRONT OFFICE','mangrove');
insert into pegawai values('','Karyawan1','L','KOKI','somewhere over da rainbow');
insert into pegawai values('','mister satpam','L','SATPAM','emboh');
--membership
insert into membership values('','Alfonsus Yves','mangrove','081331322570','edwin0sidharta@gmail.com',1);
--booking
insert into booking values('','ME001','KA001',TO_DATE('15/05/2019', 'dd/mm/yyyy'),TO_DATE('17/05/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('18/05/2019', 'dd/mm/yyyy'),TO_DATE('20/05/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('21/05/2019', 'dd/mm/yyyy'),TO_DATE('23/05/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('24/05/2019', 'dd/mm/yyyy'),TO_DATE('26/05/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('27/05/2019', 'dd/mm/yyyy'),TO_DATE('29/05/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('01/06/2019', 'dd/mm/yyyy'),TO_DATE('4/06/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA001',TO_DATE('05/06/2019', 'dd/mm/yyyy'),TO_DATE('8/06/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA002',TO_DATE('09/06/2019', 'dd/mm/yyyy'),TO_DATE('14/06/2019', 'dd/mm/yyyy'));
insert into booking values('','ME001','KA002',TO_DATE('15/06/2019', 'dd/mm/yyyy'),TO_DATE('18/06/2019', 'dd/mm/yyyy'));
--user
insert into users values('alfon','1','FRONT OFFICE');
insert into users values('manajer','1','MANAGER');
insert into users values('cust','1','CUSTOMER');
--jabatan
insert into jabatan values('KOKI',4000000);
insert into jabatan values('SATPAM',3000000);
insert into jabatan values('MANAGER',30000000);
insert into jabatan values('FRONT OFFICE',40000000);
insert into jabatan values('CUSTOMER',0);
--htrans
insert into h_transaksi values('TR001','KA001','1000000','ME001','KB001',TO_DATE('15/05/2019', 'dd/mm/yyyy'),TO_DATE('17/05/2019', 'dd/mm/yyyy'));
insert into h_transaksi values('TR002','KA001','800000','ME001','KB002',TO_DATE('18/05/2019', 'dd/mm/yyyy'),TO_DATE('20/05/2019', 'dd/mm/yyyy'));
insert into h_transaksi values('TR003','KA001','600000','ME001','KB003',TO_DATE('21/05/2019', 'dd/mm/yyyy'),TO_DATE('23/05/2019', 'dd/mm/yyyy'));
--dtrans
insert into d_transaksi values ('TR001', 'FA001');
insert into d_transaksi values ('TR001', 'FA002');
insert into d_transaksi values ('TR002', 'FA002');
insert into d_transaksi values ('TR003', 'FA001');
insert into d_transaksi values ('TR003', 'FA002');

commit;

