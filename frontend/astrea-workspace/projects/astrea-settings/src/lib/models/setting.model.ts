export type SettingType = 'boolean' | 'number' | 'string' | 'currency' | 'date';

export interface Setting {
  id: string;           
  module: string;       
  name: string;         
  description: string;  
  defaultValue: string; 
  type: SettingType;    
}
