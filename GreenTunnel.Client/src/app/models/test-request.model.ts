export class TestRequest {
    model: {
        id: string;
        name: string;
        descrition: string; 
        tesTypeId: number;
        complianceId?: number;
        productId?: number;
    };
  
    constructor() {
      this.model = {
        id:'',
        name: '', 
        descrition: '',
        tesTypeId:0,
        complianceId:0,
        productId:0
      };
    }
  }
  