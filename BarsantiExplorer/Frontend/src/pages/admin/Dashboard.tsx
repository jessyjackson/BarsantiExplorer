import React from "react";
import { Button } from "@/components/ui/button";
import { LiaTelegramPlane } from "react-icons/lia";
import { FiEdit } from "react-icons/fi";
import { MdOutlineLibraryAdd } from "react-icons/md";
import { BiLogOutCircle } from "react-icons/bi";
import { Link } from "react-router-dom";

function Dashboard() {
	return (
		<main className="page">
			<h1 className="text-3xl font-bold text-center w-full mb-6 mt-20">
				Trips management
			</h1>
			<div className="grid grid-cols-3 gap-4 mx-auto w-max">
				<Link to="/admin/trips/new">
					<Button
						className="p-8 text-center h-56 w-56 flex flex-col items-center justify-center"
						variant="outline"
					>
						<MdOutlineLibraryAdd className="text-6xl mx-auto mb-4" />
						<p className="text-2xl font-bold">Create a trip</p>
					</Button>
				</Link>
				<Link to="/trips">
					<Button
						className="p-8 text-center h-56 w-56 flex flex-col items-center justify-center"
						variant="outline"
					>
						<FiEdit className="text-6xl mx-auto mb-4" />
						<p className="text-2xl font-bold">Manage trips</p>
					</Button>
				</Link>
				<Link to="/admin/telegram">
					<Button
						className="p-8 text-center h-56 w-56 flex flex-col items-center justify-center"
						variant="outline"
					>
						<LiaTelegramPlane className="text-6xl mx-auto mb-4" />
						<p className="text-2xl font-bold">Sync Telegram</p>
					</Button>
				</Link>
			</div>
			<div className="mt-24 w-full">
				<Button
					className="mx-auto block text-destructive hover:text-destructive flex gap-2"
					variant="ghost"
				>
					<BiLogOutCircle className="text-2xl" />
					Logout
				</Button>
			</div>
		</main>
	);
}

export default Dashboard;
