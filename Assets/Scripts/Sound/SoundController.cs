using UnityEngine;

namespace Assets.Scripts.Sound{

    public class SoundController : MonoBehaviour{
	    private static SoundController soundController;

	    public AudioClip wrongAnswerSound;
	    public AudioClip rightAnswerSound;
	    public AudioClip levelCompleteSound;
	    public AudioClip clickSound;
        public AudioClip music;

        public AudioSource soundSource;
	    public AudioSource musicSource;

        void Awake(){
            if (soundController == null){
                soundController = this;
            }
            else if (soundController != this){
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
        }       
    
        public void PlayClip(AudioClip customClip){
	        soundSource.clip = customClip;
	        soundSource.Play();
        }

        public void PlayWrongSound(){
		       soundSource.clip = wrongAnswerSound;
		        soundSource.Play();
	        
        }

        public void PlayClickSound(){
		    soundSource.clip = clickSound;
		    soundSource.Play();    
        }

        public void PlayRightAnswerSound(){ 
		    soundSource.clip = rightAnswerSound;
		    soundSource.Play();
        }

        public void PlayLevelCompleteSound(){
		    soundSource.clip = levelCompleteSound;
		    soundSource.Play();
        }    

        public void PlayMusic(){
			musicSource.clip = music;
		    musicSource.Play();         	
        }

        public void StopMusic(){
	        musicSource.Stop();
        }

        public void StopSound(){
            soundSource.Stop();
        }

        public static SoundController GetController(){
            return soundController;
        }
    }
}