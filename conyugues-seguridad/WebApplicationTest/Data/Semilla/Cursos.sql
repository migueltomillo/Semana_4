--opción 1
insert into Cursos(Nombre, NumeroCreditos) values ('POO', 80);
insert into Cursos(Nombre, NumeroCreditos) values ('ASP.NET Core 5.0', 110);
insert into Cursos(Nombre, NumeroCreditos) values ('Angular', 90);

--opción 2
SET IDENTITY_INSERT Cursos ON
insert into Cursos(CursoId, Nombre, NumeroCreditos) values (1, 'Angular', 90);
insert into Cursos(CursoId, Nombre, NumeroCreditos) values (2, 'ASP.NET Core 5.0', 110);
insert into Cursos(CursoId, Nombre, NumeroCreditos) values (3, 'POO', 80);
SET IDENTITY_INSERT Cursos OFF

SET IDENTITY_INSERT Empleados ON
insert into Empleados(EmpleadoId, Nombre, Apellido, Salario, Nacimiento) values (3, 'Miguel', 'Tomillo', 700, '2000-03-21');
SET IDENTITY_INSERT Empleados OFF

insert into CursoEmpleado (CursosCursoId, ParticipantesEmpleadoId) values (1,3);
insert into CursoEmpleado (CursosCursoId, ParticipantesEmpleadoId) values (2,3);
insert into CursoEmpleado (CursosCursoId, ParticipantesEmpleadoId) values (3,3);
