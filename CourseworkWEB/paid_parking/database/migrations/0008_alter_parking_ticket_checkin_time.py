# Generated by Django 3.2.6 on 2021-10-18 20:14

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('database', '0007_auto_20211017_1350'),
    ]

    operations = [
        migrations.AlterField(
            model_name='parking_ticket',
            name='checkin_time',
            field=models.DateTimeField(auto_now=True, verbose_name='Check In Time'),
        ),
    ]
