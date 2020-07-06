
export class CopaService{

    static async obterEquipes() {
        return await fetch('api/Copa/ObterEquipes');                    
    }

    static async GerarCopa(equipesSelecionadas) {
        
        const data = {
            Equipes: Array.from(equipesSelecionadas)
        };        
      
        return await fetch('api/Copa/GerarCopa', {
            method: 'POST',
            body: JSON.stringify(data),
            headers: new Headers({
                'Content-Type':'application/json'
            })
        });                            
    }
}

