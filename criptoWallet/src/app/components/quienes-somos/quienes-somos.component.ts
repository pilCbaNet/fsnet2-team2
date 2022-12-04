import { Component, OnInit } from '@angular/core';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-quienes-somos',
  templateUrl: './quienes-somos.component.html',
  styleUrls: ['./quienes-somos.component.css'],
})
export class QuienesSomosComponent implements OnInit {
  team: any;

  constructor(private miServicio: TeamService) {}

  ngOnInit(): void {
    this.miServicio.obtenerDatosTeam().subscribe((data) => {
      this.team = data;
    });
  }
}
