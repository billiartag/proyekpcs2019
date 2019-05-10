--jenis kamar
insert into jenis_kamar values(' ','Luxury',500000);
--kamar
insert into kamar values(' ','JK001','ya',to_date(sysdate,'dd/mm/yyyy'));
insert into kamar values(' ','JK001','ya','');
insert into kamar values(' ','JK001','ya',to_date(sysdate,'dd/mm/yyyy'));
--fasilitas
insert into fasilitas values('','kolam renang',100000,'kolam renang');
--pegawai
insert into pegawai values('','Alfonsus Yves','L','Direktur','mangrove');
--membership
insert into membership values('','Alfonsus Yves','mangrove','081331322570','edwin0sidharta@gmail.com');
--booking
insert into booking values('','ME001','KA001',to_date(sysdate,'dd/mm/yyyy'),to_date(sysdate,'dd/mm/yyyy'));
commit;