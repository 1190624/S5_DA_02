import { TestBed } from '@angular/core/testing';

import { CamiaoService } from './camiao.service';

describe('CamiaoService', () => {
  let service: CamiaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CamiaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
