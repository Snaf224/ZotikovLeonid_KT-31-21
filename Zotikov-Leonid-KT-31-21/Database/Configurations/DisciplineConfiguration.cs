using Zotikov_Leonid_KT_31_21.Database.Helpers;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zotikov_Leonid_KT_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.DisciplineId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор предмета");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");


            //связь со студентами
            builder.HasOne(p => p.Student)
            .WithMany()
            .HasForeignKey(p => p.StudentId)
            .HasConstraintName("fk_f_student_id")
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.StudentId, $"idx_{TableName}_fk_f_group_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Student)
                .AutoInclude();

            builder.ToTable(TableName);
        }
    }
}
