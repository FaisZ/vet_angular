import { Component, OnInit } from '@angular/core';
import { Appointment } from './appointment';
import { APPOINTMENTS } from './mock-appointments';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  appointments = APPOINTMENTS;
  selectedAppointment?: Appointment;

  constructor() { }

  ngOnInit(): void {
  }
  onSelect(appointment: Appointment): void {
    this.selectedAppointment = appointment;
  }
}
