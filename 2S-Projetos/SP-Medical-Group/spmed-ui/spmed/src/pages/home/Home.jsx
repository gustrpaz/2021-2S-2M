import React from 'react'
import { Link, useHistory } from 'react-router-dom'
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import "../../assets/css/home.css"

import fundo_quemSomos from '../../assets/img/undraw_medicine_b1ol.svg'
import fundo1_banner from '../../assets/img/maobebe.png'
import fundo2_banner from '../../assets/img/medicos.png'
import fundo_section from '../../assets/img/exame.png'


export default function Home() {

     let history = useHistory();

//      var myIndex = 0;
//     carousel();

//     function carousel() {
//         var i;
//         var x = document.getElementsByClassName("mySlides");
//         for (i = 0; i < x.length; i++) {
//             x[i].style.display = "none";
//         }
//         myIndex++;
//         if (myIndex > x.length) {
//             myIndex = 1
//         }
//         x[myIndex - 1].style.display = "flex";
//         setTimeout(carousel, 6000);
//     }

//     function BotaoDoMenu() {
//             var menu = document.getElementById("links");
//             if (menu.style.display == "flex") {
//                 // Esconda o menu 
//                 menu.style.display = "none";
//             } else {
//                 //Mostre o menu
//                 menu.style.display = "flex"
//             }
//         }

     function redirecionar(){
          console.log()
          switch (parseJwt().role) {
               case "1":
                   history.push("/listaConsulta")
                   console.log("estou logado: " + usuarioAutenticado())
                   break;

               case "2":
                   history.push("/listaConsultasMed")
                   console.log("estou logado: " + usuarioAutenticado())
                   break;

               case "3":
                   history.push("/listaConsultaPac")
                   console.log("estou logado: " + usuarioAutenticado())
                   break;
           
               default:
                   history.push("/")
                   break;             
           }
       }
     
     return (

          <div>
               <Header/>
               <main>

                    <div id="home" className="container_banner banner mySlides fade">
                         <img src= {fundo1_banner} alt="plano de fundo bebê" />
                         <div className="box_conteudo">
                              <h1>Welcome to spmedicalgroup</h1>
                         </div>
                    </div>

                    {/* <div id="home" className="container_banner banner2 mySlides fade">
                         <img src={fundo2_banner} alt="plano de fundo médicos" />
                         <div className="box_conteudo">
                              <h1>Welcome to spmedicalgroup</h1>
                         </div>
                    </div> */}

                    <section className="container_section">
                         <div className="box_consultas">
                              <div className="box_conteudo_section">

                                 <button onClick={redirecionar} className="box1">

                                        <span>Consultas</span>
                                       
                                        <hr/>
                                   </button>
                         

                                   <div className="box2">
                                             <a href="#quemsomos">Unidade</a>
                                         <hr /> 
                                   </div>

                               </div>
                         </div>
                    </section>

                              <section className="container_especialidades">
                                   <div className="container_interno">
                                        <div className="box_especialidade">
                                             <span>Especialidades</span>
                                        </div>
                                        <div className="box_conteudo_especialidade">
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <span>Cardiologia</span>
                                             </div></Link>
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <span>Angiologia</span>
                                             </div></Link>
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <span>Urulogia</span>
                                             </div></Link>
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <span>Pediatra</span>
                                             </div></Link>
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <span>Cirurgia</span>
                                             </div></Link>
                                             <Link to="/especialidade"><div className="caixas_especialidade">
                                                  <Link to="/especialidade"><span>Psquiatria</span></Link>
                                             </div> </Link>
                                        </div>
                                        <div className="box_VerTodas">
                                             <Link to="/especialidade"><span>Ver todas</span></Link>
                                        </div>
                                   </div>
                              </section>

                              <section className="container_sessao">
                                   <img src={fundo_section} />
                              </section>

                              <section id="quemsomos" className="quem_somos">
                                   <div className="img_quemSomos">
                                       
                                        <img src= {fundo_quemSomos} alt="desenho médico" />
                                   </div>
                                   <div className="txt_quemSomos">
                                        <h1>Quem somos</h1>
                                        <p>
                                             Fundada em 2021 em São Paulo, a clínica Sp Medical Group foi fundada por Gustavo Rezende Paz, com o
                                             intuito de ser uma rede integrada de cuidados com a sáude no Brasil, atualmente somente em São
                                             Paulo, com foco em serviços humanizados, qualificação de funcionários, adoção de novas tecnologias e
                                             expansão de serviços, a fim de melhorar a qualidade na área da saúde.
                                        </p>
                                        <p>
                                             Rua Alameda Barão de Limeira, 539 - Santa Cecilia, São Paulo - SP, 01202-001
                                        </p>
                                   </div>
                              </section>

               </main>

          <Footer/>

     </div>
              

      );
}



