import { TestBed } from '@angular/core/testing';

import { EmployeeDependentServiceService } from './employee-dependent-service.service';

describe('EmployeeDependentServiceService', () => {
  let service: EmployeeDependentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeDependentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
