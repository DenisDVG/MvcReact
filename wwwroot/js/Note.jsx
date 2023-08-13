class Note extends React.Component {
    state = { data: this.props.initialData };

    render() {
		const notes = this.state.data.map((note) =>
			<li key={note.id}>
				{note.content}
			</li>
		);
		return (
			<div>It`s React List:
				<ul>{notes}</ul>
			</div>
		);
    }
}



//import * as React from 'react';

//type Props = {
//    initialData: INoteViewModel[]
//};

//export interface INoteViewModel {
//    id: number;
//    title: string;
//    content: string;
//}

//const Note: React.FC<Props> = ({ initialData }) => {
//    const notes = initialData.map((note) =>
//        <li key={note.id}>
//            {note.content}
//        </li>
//    );
//    return (
//        <div>It`s React List:
//            <ul>{notes}</ul>
//        </div>
//    );
//};
//export default Note;



