/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ContractorService } from './contractor.service';

describe('Service: Contractor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractorService]
    });
  });

  it('should ...', inject([ContractorService], (service: ContractorService) => {
    expect(service).toBeTruthy();
  }));
});
