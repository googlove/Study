# Generated by Django 3.2.6 on 2021-10-16 17:33

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('database', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='parking_ticket',
            name='checkin_time',
            field=models.DateTimeField(verbose_name='Check In Time'),
        ),
        migrations.AlterField(
            model_name='parking_ticket',
            name='checkout_time',
            field=models.DateTimeField(verbose_name='Check Out Time'),
        ),
        migrations.CreateModel(
            name='Total_Amount',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('car', models.CharField(max_length=50, verbose_name='Car')),
                ('total_due', models.FloatField(verbose_name='Total Due')),
                ('tickets', models.ManyToManyField(to='database.Parking_Ticket', verbose_name='Tickets')),
            ],
        ),
    ]
