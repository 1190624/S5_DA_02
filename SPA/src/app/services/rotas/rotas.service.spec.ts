import { TestBed } from '@angular/core/testing';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { RotasService } from './rotas.service';

describe('RotasService', () => {
  let service: RotasService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers:[
        RotasService
        //HttpErrorHandler
      ]
    });
    TestBed.configureTestingModule({});
    service = TestBed.inject(RotasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
