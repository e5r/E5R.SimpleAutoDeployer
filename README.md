E5R.SimpleAutoDeployer
======================

Simple Automatic Deployer

Sistema simples e autom�tico para implementa��o de softwares.

## Ideia basica

* e5rsad.exe escutando as mudan�as nos diret�rios:
    * __/wainting__: Tarefas em espera [[provavelmente s� esta � suficiente]]
    * __/initiated__: Tarefas iniciadas
    * __/completed__: Tarefas completadas
* As tarefas s�o descritas em arquivos _JSON_;
* e5rsad.exe mantem uma fila das tarefas
* Quando um arquivo novo � detectado um objeto __TaskBase__ � criado e inclu�do na fila`__waiting__;
* Ap�s a conclus�o de uma tarefa, e/ou de tempos em tempos a pr�xima tarefa � iniciada:
    * A� a mesma � removida do diret�rio (e da fila) __waiting__ e movida para __initiated__;
* Quando uma tarefa � finalizada (com sucesso ou erro) a mesma � movida da fila (e do diret�rio) __initiated__ para __completed__;
    * E a pr�xima tarefa (se ouver � iniciada)
