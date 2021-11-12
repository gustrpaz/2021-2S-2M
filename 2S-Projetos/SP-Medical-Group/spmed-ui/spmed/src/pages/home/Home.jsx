import React from 'react'
import { Link } from 'react-router-dom'
import Footer from '../../components/footer/footer'
import Header from '../../components/header/header'
import "../../assets/css/home.css"

import fundo_quemSomos from '../../assets/img/undraw_medicine_b1ol.svg'
import fundo1_banner from '../../assets/img/maobebe.png'
import fundo2_banner from '../../assets/img/medicos.png'

import fundo_section from '../../assets/img/exame.png'

export default function Home() {

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

                                   <div className="box1">
                                        <Link to="/listaConsulta"><a href="btn_consulta">Consultas</a></Link>
                                        <hr/>
                                   </div>

                                   <div className="box2">
                                             <a href="btn_consulta">Unidade</a>
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
                                             <div className="caixas_especialidade">
                                                  <span>Cardiologia</span>
                                             </div>
                                             <div className="caixas_especialidade">
                                                  <span>Angiologia</span>
                                             </div>
                                             <div className="caixas_especialidade">
                                                  <span>Urulogia</span>
                                             </div>
                                             <div className="caixas_especialidade">
                                                  <span>Pediatra</span>
                                             </div>
                                             <div className="caixas_especialidade">
                                                  <span>Cirurgia</span>
                                             </div>
                                             <div className="caixas_especialidade">
                                                  <span>Psquiatria</span>
                                             </div>
                                        </div>
                                        <div className="box_VerTodas">
                                             <span>Ver todas</span>
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



